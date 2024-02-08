import { useState } from 'react';

const useApiRequest = () => {
    const [isLoading, setIsLoading] = useState(false);
    const token = localStorage.getItem('token');

    const makeRequest = async (endpoint, method, body) => {
        setIsLoading(true);
        let errorMessage = '';

        try {
            const response = await fetch(endpoint, {
                method: method,
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`,
                },
                body: JSON.stringify(body),
            });

            if (!response.ok) {
                const errorData = await response.json();
                errorMessage = errorData.errors[0];
                throw new Error(errorMessage);
            }

            return await response.json();
        } catch (error) {
            console.error('Error occurred:', error.message);
            throw new Error(errorMessage != null ? errorMessage : 'An error occurred.Please try again.');
        } finally {
            setIsLoading(false);
        }
    };

    return { makeRequest, isLoading };
};

export default useApiRequest;
